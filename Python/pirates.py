def process(after, input):
    # convert list of tuples to a list of lists
    list_input = [list(elem) for elem in input]
    pirate_list = []

    my_position = find_total_number_of_people(input) - after - 2
    people_count = find_total_number_of_people(input)

    # sorts list based on first value in each sublist
    list_input.sort(key=lambda x: x[0])

    current_position = 0

    first_index_list = []

    # populate the pirate list with all pirates
    for person in range(people_count):
        pirate_list.append(Pirate(current_position))
        current_position += 1
    current_position = 0  # reset the current position

    for person in range(people_count):
        while current_position < len(pirate_list):
            first_index_list = [item[1] for item in list_input]
            max_value = max(first_index_list)
            max_value_index = first_index_list.index(max_value)
            pirate_list[current_position].string += list_input[max_value_index][0] + ':' + str(max_value) + ' '
            list_input[max_value_index].pop(1)
            # check if list_input sublist has no more values
            for sublist in list_input:
                if len(sublist) == 1:
                    list_input.remove(sublist)
            first_index_list.clear()
            current_position += 1

    pirate_list.reverse()
    current_position = 0

    for person in range(people_count):
        while current_position < len(pirate_list):
            first_index_list = [item[1] for item in list_input]
            max_value = max(first_index_list)
            max_value_index = first_index_list.index(max_value)
            pirate_list[current_position].string += list_input[max_value_index][0] + ':' + str(max_value)
            list_input[max_value_index].pop(1)
            # check if list_input sublist has no more values
            for sublist in list_input:
                if len(sublist) == 1:
                    list_input.remove(sublist)
            first_index_list.clear()
            current_position += 1

    return pirate_list[after].to_string()


def find_total_number_of_people(input_list):
    number_count = 0
    for index in input_list:
        for entry in index:
            if is_string_an_int(entry):
                number_count += 1

    return int(number_count / 2)


def is_string_an_int(number):
    try:
        int(number)
        return True
    except ValueError:
        return False


class Pirate:
    def __init__(self, position):
        self.position = position
        self.string = ""

    def to_string(self):
        return self.string
