-- Ask temperature in Celsius then convert to Fahrenheit
-- For 23 result is 73.4
-- For 36.6 result is 97.88000000000001


temperatureFahrenheit temperatureCelsius = 32 + temperatureCelsius * 9 / 5

main = do
    putStrLn "What is temperature in Celsius?"
    c <- readLn
    let result = temperatureFahrenheit c
    putStrLn ("It's " ++ show result ++ " in Fahrenheit")