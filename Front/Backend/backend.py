import argparse
import utils as ut

# Parser initializer
parser = argparse.ArgumentParser(
    prog='Noiseless netting',
    description='Filtering noisy data',
    epilog='AxoloTech')

# Valid arguments
parser.add_argument('--filename', required=True)
parser.add_argument('--graphic', choices=['plot', 'spectrogram'], nargs='+')
args = parser.parse_args()

for path in ut.denoising_data(args):
    print(path)
