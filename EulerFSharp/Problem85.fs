module ProjectEuler.EulerFSharp.Problem85

// formula for number of rectangles in a grid h x w is triangular(h) x triangular (w)
// i.e. h(h+1)w(w+1)/4

// for each triangular number up to 1414 ~= sqrt (2,000,000), check which other triangular number gives product closest to 2,000,000
// keep track of the h, w that give the closest
// answer is h x w

// not very efficient but it doesn't really matter
let solution =
    let target = 2000000
    let maxNumber = 1415
    let numberOfRectangles height width = height * width * (height + 1) * (width + 1) / 4
    let possibles = seq {
        for height in 1 .. maxNumber do
            for width in 1 .. maxNumber do
                yield (height * width, numberOfRectangles height width) }
    let (area, rects) = Seq.minBy (fun (area, rect) -> abs(rect - target)) possibles
    area
