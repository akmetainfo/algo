module Kata (findOutlier) where

evenNumbers x = [ c | c <- x, even c]
oddNumbers x = [ c | c <- x, odd c]

lengthOfEvenNumbers x = length(evenNumbers x)
lengthOfoddNumbers x =  length(oddNumbers x)

findOutlier :: [Int] -> Int 
findOutlier xs = error "todo"
