import argparse
import utils as ut


# Parser initializer
parser = argparse.ArgumentParser(
    prog='Noiseless netting',
    description='Filtering noisy data',
    epilog='AxoloTech')

# Valid arguments
parser.add_argument('--filename', required=True)
parser.add_argument('--graphic', choices=['plot', 'spectrogram'])
args = parser.parse_args()


ut.save_plot(args.filename)
