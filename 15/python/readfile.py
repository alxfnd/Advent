import os

def read_file(day):
    directory = os.path.dirname(__file__) + '\\'
    return open(f'{directory}day{day}.txt').readlines()