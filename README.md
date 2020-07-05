# Comparing async io between tech stacks

* Perform 100 requests to load json from a website.
* Await them all.
* Output the last one.
* Rubbish benchmarking.

## C# - dotnet run -c Release

3.1.300

Elapsed: 0.8227044 seconds
Result: {
  "userId": 5,
  "id": 100,
  "title": "excepturi a et neque qui expedita vel voluptate",
  "completed": false
}

## Rust - cargo run --release

stable-x86_64-apple-darwin, rustc 1.44.1

Elapsed: 0.461528377 seconds
Result: {"completed":false,"id":100,"title":"excepturi a et neque qui expedita vel voluptate","userId":5}
