-- Ask name and write greeting at console

main = do  
    putStrLn "Hello, what's your name?"  
    name <- getLine  
    putStrLn ("Hey, " ++ name ++ ", you're welcome!") 
