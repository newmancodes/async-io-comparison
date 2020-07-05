package main

import (
	"fmt"
	"sync"
	"time"
)

func main() {
	start := time.Now()

	elapsed := time.Since(start)
	fmt.Printf("Elapsed: %v seconds\n", elapsed.Seconds)
	fmt.Printf("Result: %s\n", "nothing")
}
