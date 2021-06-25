-- Ask mass and height, then calculate BMI (body mass index)
-- Result for mass = 77 and height = 1.70 is 26.643598615916957

bmi mass height = mass / (height * height)

main = do  
    putStrLn ("Enter your mass in kilos")
    mass <- readLn
    putStrLn ("Enter your height in meters")
    h <- getLine
    let height = (read h :: Double)
    let result = bmi mass height
    putStrLn ("Your body mass index is " ++ show result)
