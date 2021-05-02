-- Ask temperature in Celsius then convert to Kelvin

temperatureKelvin temperatureCelsius = temperatureCelsius + 273

main = do
    putStrLn "What is temperature in Celsius?"
    c <- readLn
    let result = temperatureKelvin c
    putStrLn ("It's " ++ show result ++ " in Kelvin")