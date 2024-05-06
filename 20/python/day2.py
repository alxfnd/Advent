from readfile import read_file

puzzle_input = read_file('2')

def interpret_code(line):
    count, letter, code = line.split()
    min, max = count.split('-')
    min = int(min) - 1
    max = int(max) - 1
    return [(min,max),letter[0],code]

interpreted_list = [interpret_code(line) for line in puzzle_input]

def is_valid(code):
    min, max = code[0]
    min += 1
    max += 2
    return code[2].count(code[1]) in range(min, max)

def is_valid_two(code):
    min, max = code[0]
    if code[2][min] == code[1]:
        return not code[2][max] == code[1]
    return code[2][max] == code[1]

valid_list_one = [is_valid(code) for code in interpreted_list]
valid_list_two = [is_valid_two(code) for code in interpreted_list]

print(valid_list_one.count(True))
print(valid_list_two.count(True))