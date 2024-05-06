from readfile import read_file

puzzle_input = read_file('1', True)

puzzle_answer = 0

for line in puzzle_input:
    sum = (2020 - line)
    if sum in puzzle_input:
        puzzle_answer = line * sum
        break

print(puzzle_answer)

def return_three_value(starting_value, rest_of_values):
    sum = 2020 - starting_value
    for number in rest_of_values:
        if (sum - number) in rest_of_values:
            return starting_value * number * (sum - number)
    return None

for line in puzzle_input:
    copy_list = puzzle_input.copy()
    copy_list.remove(line)
    line_check = return_three_value(line, copy_list)
    if line_check:
        print(line_check)
        break

