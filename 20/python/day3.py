from readfile import read_file

puzzle_input = read_file('3')

tree_map = [line for line in puzzle_input]

trees_hit = 0
speed = (3,1)
distance = 3
current_layer = 1
bottom_layer = len(tree_map)
map_width = len(tree_map[0])

while current_layer < bottom_layer:
    if distance >= map_width:
        distance -= (map_width - 1)
    if tree_map[current_layer][distance] == '#':
        trees_hit += 1
    distance += speed[0]
    current_layer += speed[1]

print(trees_hit)