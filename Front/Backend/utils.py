import os
import shutil

from obspy import read


def recreate_directory(directory_path):
    if os.path.exists(directory_path):
        # Eliminar el directorio existente
        shutil.rmtree(directory_path)

    # Crear el nuevo directorio
    os.makedirs(directory_path)


def save_plot(filename, save_dir):
    if not filename.endswith('.mseed'):
        return

    recreate_directory(save_dir)

    single_channel = read(filename)
    plot_path = os.path.join(save_dir, os.path.basename(filename) + '_plot.png')
    single_channel.plot(outfile=plot_path)
    print(f"Plot saved to {plot_path}")


def process_files(resource_dir, save_dir):
    recreate_directory(save_dir)
    for root, dirs, files in os.walk(resource_dir):
        for file in files:
            if file.endswith('.mseed'):
                file_path = os.path.join(root, file)
                print(f"Processing {file_path}")
                save_plot(file_path, save_dir)
