evenNumbers x = [ c | c <- x, even c]
oddNumbers x = [ c | c <- x, odd c]

lengthOfEvenNumbers x = length(evenNumbers x)
lengthOfoddNumbers x =  length(oddNumbers x)

main = do
    let a = [42, 0, -7, 2]
    putStrLn ("A is " ++ show a)

    putStrLn ("Even from a is " ++ show(evenNumbers a))    
    putStrLn ("Even length is " ++ show(lengthOfEvenNumbers(a)))

    putStrLn ("First even from a is " ++ show(head(evenNumbers a)))


    putStrLn ("Odd from a is " ++ show(oddNumbers a))    
    putStrLn ("Odd length is " ++ show(length(oddNumbers a)))
    
    putStrLn ("First odd from a is " ++ show(head(oddNumbers a)))
    
