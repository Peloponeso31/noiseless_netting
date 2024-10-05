import argparse
from obspy.core import read

# Parser initializer
parser = argparse.ArgumentParser(
    prog='Noiseless netting',
    description='Filtering noisy data',
    epilog='AxoloTech')

# Valid arguments
parser.add_argument('--filename', required=True)
parser.add_argument('--graphic', choices=['plot', 'spectrogram'])
args = parser.parse_args()

single_channel = read(args.filename)
single_channel.plot()


def main():
    print(args.filename)


if __name__ == '__main__':
    main()
