-- Ask temperature in Celsius then convert to Kelvin

temperatureKelvin temperatureCelsius = temperatureCelsius + 273

main = do
    putStrLn "What is temperature in Celsius?"
    c <- getLine
    let temperatureCelsius = (read c :: Int)
    let result = temperatureKelvin temperatureCelsius
    putStrLn ("It's " ++ show result ++ " in Kelvin")