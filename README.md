# SentimentAnalysis
Learning WPF (C#&amp; / .NetCore) : Sentiment Analysis of user input text

This is a simple WPF .NetCore Application that uses XAML front end and C# as the backend.

Input: User inputs the answer to "Hi, How are you feeling today?" in the WPF UI.

Processing: The application makes an HTTP POST request to a public Web API that provides sentiment analysi result.

Public Web API used: https://sentim-api.herokuapp.com/

Output: The Web API returns a JSON response, which the application then parses to determine the overall sentiment of the user input.
