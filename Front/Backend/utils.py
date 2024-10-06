import os
import shutil

from obspy import read


def recreate_directory(directory_path):
    if os.path.exists(directory_path):
        # Eliminar el directorio existente
        shutil.rmtree(directory_path)

    # Crear el nuevo directorio
    os.makedirs(directory_path)


def save_plot(filename):
    if not filename.endswith('.mseed'):
        return

    base_path = f"{os.getcwd()}\\plots" 
    #recreate_directory(base_path)

    single_channel = read(filename)
    plot_path = os.path.join(base_path, os.path.basename(filename) + '_plot.png')
    single_channel.plot(outfile=plot_path)
    print(f"{plot_path}")


def process_files(resource_dir, save_dir):
    recreate_directory(save_dir)
    for root, dirs, files in os.walk(resource_dir):
        for file in files:
            if file.endswith('.mseed'):
                file_path = os.path.join(root, file)
                print(f"Processing {file_path}")
                save_plot(file_path, save_dir)
