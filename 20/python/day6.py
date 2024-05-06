from readfile import read_file
from collections import defaultdict

instructions = read_file('6')

# Default dict allows you to access keys that don't already exist
light_dict_one = defaultdict(bool) # All values are False
light_dict_two = defaultdict(int) # All values are 0

def read_instruction(inst):
    if inst.startswith('turn on'):
        intent = 0
    elif inst.startswith('turn off'):
        intent = 1
    else:
        intent = 2
        return (intent, inst.split()[1::2])
    return (intent, inst.split()[2::2])

def amend_dict(intent, coord_set):
    for coord in coord_set:
        match intent:
            case 0:
                light_dict_one[coord] = True
                light_dict_two[coord] = light_dict_two[coord] + 1
            case 1:
                light_dict_one[coord] = False
                light_dict_two[coord] = light_dict_two[coord] - 1 if light_dict_two[coord] > 0 else 0
            case 2:
                light_dict_one[coord] = not light_dict_one[coord]
                light_dict_two[coord] = light_dict_two[coord] + 2

def format_coord(x,y):
    return f'{x},{y}'

def calculate_lights():
    new_instructions = [read_instruction(line) for line in instructions]
    for intent, coord in new_instructions:
        xstart, ystart = coord[0].split(',')
        xstop, ystop = coord[1].split(',')
        xstop = int(xstop) + 1; ystop = int(ystop) + 1
        coord_set = {format_coord(x, y) for x in range(int(xstart), xstop) for y in range(int(ystart), ystop)}
        amend_dict(intent, coord_set)
    
    #One
    print(f'Part One: {len([val for val in light_dict_one.values() if val == True])}')

    #Two
    print(f'Part Two: {sum([val for val in light_dict_two.values()])}')

calculate_lights()


# Part One
#519704 - Too low
#569999

# Part Two
#17325717 - Too low
#17558583 - Too low # Function was allowing "turn off" to let the value go below 0
#17836115
