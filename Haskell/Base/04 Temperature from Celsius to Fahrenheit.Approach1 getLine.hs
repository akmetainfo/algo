-- Ask temperature in Celsius then convert to Fahrenheit

temperatureFahrenheit temperatureCelsius = 32 + temperatureCelsius * 9 / 5

main = do
    putStrLn "What is temperature in Celsius?"
    c <- getLine
    let temperatureCelsius = (read c :: Int)
    let result = temperatureKelvin temperatureCelsius
    putStrLn ("It's " ++ show result ++ " in Kelvin")