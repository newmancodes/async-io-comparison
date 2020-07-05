# Comparing async io between tech stacks

* Perform 200 requests to load json from a website.
* Await them all.
* Output the last one.
* Rubbish benchmarking.

## C# - dotnet run -c Release

5.0.100-preview.6.20318.15

DOTNET_SYSTEM_THREADING_POOLASYNCVALUETASKS:1
Elapsed: 1.3795967 seconds
Result: {
  "userId": 10,
  "id": 200,
  "title": "ipsam aperiam voluptates qui",
  "completed": false
}

## Go - go build, ./go-async-io

go version go1.14.3 darwin/amd64

## Rust - cargo run --release

stable-x86_64-apple-darwin, rustc 1.44.1

Elapsed: 0.494690097 seconds
Result: {"completed":false,"id":200,"title":"ipsam aperiam voluptates qui","userId":10}
