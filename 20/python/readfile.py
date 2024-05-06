import os

def read_file(day, is_int=False):
    directory = os.path.dirname(__file__) + '\\'
    file = open(f'{directory}day{day}.txt').readlines()
    if is_int:
        return [int(line) for line in file]
    return file