-- Ask temperature in Celsius then convert to Fahrenheit

temperatureFahrenheit temperatureCelsius = 32 + temperatureCelsius * 9 / 5

main = do
    putStrLn "What is temperature in Celsius?"
    c <- readLn
    let result = temperatureFahrenheit c
    putStrLn ("It's " ++ show result ++ " in Kelvin")