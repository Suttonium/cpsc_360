range :: (Real a)=> [a] -> a
range a
 |a == [] = 0
 |otherwise = maximum a - minimum a



sorted :: (Ord a) => [a] -> Bool
sorted [] = True
sorted [x] = True
sorted(x:y:z) = x <= y && sorted(y:z)



primes = filterPrime [2..] 
  where filterPrime (p:xs) = 
          p : filterPrime [x | x <- xs, x `mod` p /= 0]

nprime :: Int -> Int
nprime a
 |a <= 0 = error "no negatives allowed"
 |otherwise = primes!!(a-1)



bills:: Integer -> (Integer, Integer, Integer, Integer)
bills amount
 |amount < 0 = error "no negatives allowed"
 |otherwise =(w,x,y,z)
     where
       w = amount`div`20
       x = (amount-(w*20))`div`10
       y = (amount-(w*20)-(x*10))`div`5
       z = (amount-(w*20)-(x*10)-(y*5))`div`1