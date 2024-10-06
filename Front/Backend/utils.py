import shutil
import os
import sys
import numpy as np
from sklearn.cluster import DBSCAN

from obspy import read


def create_directory(directory_path):
    if not os.path.exists(directory_path):
        # Crear el nuevo directorio
        os.makedirs(directory_path)

def denoising_data(args):
    filename = args.filename
    if not filename.endswith('.mseed'):
        return

    paths = []
    create_directory('plots')
    noisy_imgs = generate_plot(filename)
    filtered_file = load_and_process_mseed_files(filename)
    
    for path in noisy_imgs:
        paths.append(path)
    paths.append(filtered_file)
    
    return paths


#
#
#
#
#
#
#
#
# Función para preprocesar una traza sísmica específica
#
#
#
#
#
#

# Cargar y procesar los archivos .mseed de entrada
"""
def load_and_process_mseed_file(filepath):
    st = read(filepath)  # Leer archivo .mseed
    for tr in st:
        tr = preprocess_trace(tr)  # Preprocesar la traza
        features = extract_features(tr)  # Extraer características
        features = np.array(features).reshape(1, -1)  # Ajustar la forma para DBSCAN

        # Obtener parámetros para DBSCAN
        eps, min_samples = optimize_dbscan_params(features)

        # Aplicar DBSCAN
        DBSCAN(eps=eps, min_samples=min_samples)

        # Guardar solo el archivo .mseed
        save_mseed_file(tr, save_dir, os.path.basename(filepath))
"""


# Cargar y procesar los archivos .mseed de entrada
def load_and_process_mseed_files(filename):
    all_features = []
    traces = []

    st = read(filename)  # Leer archivo

    for tr in st:
        tr = preprocess_trace(tr)  # Preprocesar la traza
        features = extract_features(tr)  # Extraer características
        all_features.append(features)  # Acumular características
        traces.append((tr, filename))  # Guardar la traza y su nombre de archivo original

    # Convertir la lista de características a un array numpy
    all_features = np.array(all_features)

    # Obtener parámetros para DBSCAN
    eps, min_samples = optimize_dbscan_params(all_features)

    # Aplicar DBSCAN
    dbscan = DBSCAN(eps=eps, min_samples=min_samples)
    labels = dbscan.fit_predict(all_features)
    filter_file = None

    # Guardar las trazas filtradas que no sean ruido (label != -1)
    for i, (tr, filename) in enumerate(traces):
        if labels[i] != -1:  # Si el label es diferente de -1, no es considerado ruido
            filter_file = save_mseed_file(tr, filename)

    return filter_file

def preprocess_trace(tr, freqmin=0.5, freqmax=None):
    nyquist_frequency = tr.stats.sampling_rate / 2
    if freqmax is None or freqmax >= nyquist_frequency:
        freqmax = nyquist_frequency * 0.95

    # Aplicar filtro de paso banda
    tr.filter('bandpass', freqmin=freqmin, freqmax=freqmax)

    return tr

# No es legible.
# Función para extraer características de una traza
def extract_features(tr):
    max_amplitude = np.max(np.abs(tr.data))
    mean_frequency = np.mean(np.fft.rfftfreq(len(tr.data), d=1 / tr.stats.sampling_rate))
    energy = np.sum(tr.data ** 2)
    entropy = -np.sum((tr.data ** 2) * np.log(tr.data ** 2 + 1e-10))
    range_amplitude = np.ptp(tr.data)
    return [max_amplitude, mean_frequency, energy, entropy, range_amplitude]


# Función para optimizar los parámetros de DBSCAN
def optimize_dbscan_params(features):
    eps = np.std(features) * 2 if np.std(features) > 0 else 0.1  # Asegúrate de que eps sea positivo
    min_samples = max(1, int(np.sqrt(len(features))))  # Raíz cuadrada del número de muestras
    return eps, min_samples


# Función para guardar el archivo .mseed sin crear la gráfica
def save_mseed_file(tr, filename):
    name = os.path.splitext(os.path.basename(filename))[0]
    new_filename = f'{os.getcwd()}\\plots\\{name}_denoised.png'
    fig = tr.plot(show=False)
    fig.savefig(new_filename)
    return new_filename


def generate_plot(filename):
    tr = read(filename)
    name = os.path.splitext(os.path.basename(filename))[0]
    plot_filename = f'{os.getcwd()}\\plots\\{name}_plot.png'
    spec_filename = f'{os.getcwd()}\\plots\\{name}_spectrogram.png'

    plot = tr.plot(show=False, outfile=plot_filename)
    spec = tr.spectrogram(show=False, outfile=spec_filename)
    
    return [plot_filename, spec_filename]


def remove_extension(filename):
    return os.path.splitext(filename)[0]
