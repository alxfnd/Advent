from readfile import read_file

puzzle_input = read_file('7')

MAX_INT = 65535
variable_lookup = {}
code_for_b = ''

def interpret_code(code):
    if code[1] == '->':
        intent = 0 # Assign value
    elif code[0] == 'NOT':
        intent = 1 # Complement
    else:
        match code[1]:
            case 'AND':
                intent = 2 # AND
            case 'OR':
                intent = 3 # OR
            case 'LSHIFT':
                intent = 4 # <<
            case 'RSHIFT':
                intent = 5 # >>
    return intent

def is_in_dict(val):
    if val in variable_lookup:
        return variable_lookup.get(val)
    else:
        try:
            return int(val)
        except ValueError:
            return None

def process_code(code, intent):
    if intent > 1:
        value_one = is_in_dict(code[0])
        value_two = is_in_dict(code[2])
        if value_one is None or value_two is None:
            return None
    match intent:
        case 0: # ASSIGNMENT
            value = is_in_dict(code[0])
            if value is None:
                return None
            variable_lookup[code[2]] = value
        case 1:
            value = is_in_dict(code[1])
            if value is None:
                return None
            variable_lookup[code[3]] = MAX_INT - value
        case 2: # AND
            variable_lookup[code[4]] = value_one & value_two
        case 3: # OR
            variable_lookup[code[4]] = value_one | value_two
        case 4: # LEFT
            variable_lookup[code[4]] = value_one << value_two
        case 5: # RIGHT
            variable_lookup[code[4]] = value_one >> value_two
    return True

def process_input(code_input, part_two=False):
    while code_input:
        line = code_input.pop(0)
        splitline = line.split()
        if splitline[-1] == 'b': # Part Two
            puzzle_input.remove(line)
        intent = interpret_code(splitline)
        if process_code(splitline, intent) is None:
            code_input.append(line)

# Part One
process_input(puzzle_input.copy())
part_one = variable_lookup['a']

# Part Two
variable_lookup.clear()
variable_lookup['b'] = part_one
process_input(puzzle_input.copy())
part_two = variable_lookup['a']

print(f'Part One: {part_one}')
print(f'Part Two: {part_two}')