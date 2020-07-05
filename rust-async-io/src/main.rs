use futures::future::try_join_all;
use reqwest::Client;
use serde_json::Value;
use std::{error::Error, time::Instant};

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let client = Client::builder().build()?;
    let now = Instant::now();
    let mut gets = Vec::new();
    for id in 1..=100 {
        let get = get_todo(&client, id);
        gets.push(get);
    }
    let results = try_join_all(gets).await?;
    println!("Elapsed: {} seconds", now.elapsed().as_secs_f64());
    println!("Result: {}", results.last().unwrap().to_string());
    Ok(())
}

async fn get_todo(client: &Client, id: i32) -> Result<Value, Box<dyn Error>> {
    let base = "https://jsonplaceholder.typicode.com/todos";
    let address = format!("{}/{}", base, id);
    let response = client.get(&address).send().await?;
    Ok(response.json().await?)
}
