Задачи, которые можно решить при помощи stream api:

1512 Number of Good Pairs. Approach3 Sum of arithmetic progression

Задачи в которых нужно List привести к массиву:

350. Intersection of Two Arrays II

(мне что-то кажется, что не стоит делать так, есть вариант лучше:         return result.stream().mapToInt(x -> x).toArray();

И наоборот - массив к листу: return Arrays.stream(result).boxed().collect(Collectors.toList());

119. Pascal's Triangle II. Approach3 In-place.java - правда тут может стоило сразу объявить ArrayList известного размера