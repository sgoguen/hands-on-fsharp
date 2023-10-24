module BasicUnits =
    [<Measure>]
    type m

    [<Measure>]
    type ft

    let distance1 = 100.0<m>
    let distance2 = 300.0<ft>

    let metersToFeet = 3.28084<ft/m>
    let feetToMeters = 0.3048<m/ft>
    let ratioCheck = metersToFeet * feetToMeters

    [<Measure>]
    type s

    let time = 10.0<s>
    let speed = distance1 / time
    let acceleration = speed / time



module Example2 =
    //  Coulumb's Law

    [<Measure>]
    type C

    [<Measure>]
    type m

    [<Measure>]
    type N

    let k = 8.9875e9<N*m^2/C^2> // Coulomb's constant

    let coulombsLaw (q1: float<C>) (q2: float<C>) (r: float<m>) : float<N> = 
        k * q1 * q2 / (r * r)

    // 1. Force given charges and distance
    let forceFromChargesAndDistance (q1: float<C>) (q2: float<C>) (r: float<m>) : float<N> = k * q1 * q2 / (r * r)

    // 2. Charge given force, another charge, and distance
    let chargeFromForceDistanceAndCharge (f: float<N>) (q: float<C>) (r: float<m>) : float<C> =
        sqrt (f * r * r / (k * q))

    // 3. Distance given force and charges
    let distanceFromForceAndCharges (f: float<N>) (q1: float<C>) (q2: float<C>) : float<m> = sqrt (k * q1 * q2 / f)

    // 4. Coulomb's constant given force, charges, and distance (mostly theoretical as k is a known constant)
    let coulombsConstant (f: float<N>) (q1: float<C>) (q2: float<C>) (r: float<m>) : float<N * m^2 / C^2> =
        f * r * r / (q1 * q2)

    let charge1 = 1.0e-6<C> // 1 micro-Coulomb
    let charge2 = 2.0e-6<C> // 2 micro-Coulombs
    let distance = 0.02<m> // 2 centimeters

    let force = coulombsLaw charge1 charge2 distance
