using blazorblog.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components.Forms;

namespace blazorblog.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public PostService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["Api:BaseUrl"];

        }

        // Get all posts
        public async Task<List<Post>> GetPostsAsync()
        {
            // return await _httpClient.GetFromJsonAsync<List<Post>>("https://localhost:7154/api/Posts");
            return await _httpClient.GetFromJsonAsync<List<Post>>($"{_apiBaseUrl}/api/Posts");

            
        }

        // Get a post by ID
        public async Task<Post> GetPostByIdAsync(int id)
        {
            // return await _httpClient.GetFromJsonAsync<Post>($"https://localhost:7154/api/Posts/{id}");
            return await _httpClient.GetFromJsonAsync<Post>($"{_apiBaseUrl}/api/Posts/{id}");
        }

        // Create a new post
        public async Task<HttpResponseMessage> CreatePostAsync(Post newPost, IBrowserFile imageFile)
        {
            var formData = new MultipartFormDataContent();

            if (imageFile != null && imageFile.Size > 0)
            {
                Console.WriteLine($"Uploading file: {imageFile.Name}, Size: {imageFile.Size}");
                var stream = imageFile.OpenReadStream(maxAllowedSize: 5 * 1024 * 1024); // Limit to 5MB
                formData.Add(new StreamContent(stream), "file", imageFile.Name);
            }

            // Add other post data
            formData.Add(new StringContent(newPost.Title), "Title");
            formData.Add(new StringContent(newPost.Content), "Content");

            // Call the upload endpoint
            // var uploadResponse = await _httpClient.PostAsync("https://localhost:7154/api/Uploads", formData);
            var uploadResponse = await _httpClient.PostAsync($"{_apiBaseUrl}/api/Uploads", formData);
            
            // Log the response from the upload request
            if (uploadResponse.IsSuccessStatusCode)
            {
                var fileName = await uploadResponse.Content.ReadAsStringAsync();
                newPost.ImageFileName = fileName; // Set the uploaded file name
                Console.WriteLine($"File uploaded successfully: {fileName}");
            }
            else
            {
                var errorContent = await uploadResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Error uploading file: {uploadResponse.StatusCode}, {errorContent}");
            }

            // return await _httpClient.PostAsJsonAsync("https://localhost:7154/api/Posts", newPost);
            return await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/api/Posts", newPost);
        }


        public async Task<HttpResponseMessage> UpdatePostAsync(int id, Post updatedPost, IBrowserFile imageFile)
        {
            updatedPost.UpdatedAt = DateTime.UtcNow;

            var formData = new MultipartFormDataContent();

            // Check if an image file was selected
            if (imageFile != null && imageFile.Size > 0)
            {
                var stream = imageFile.OpenReadStream(maxAllowedSize: 5 * 1024 * 1024); // Limit file size to 5MB
                formData.Add(new StreamContent(stream), "file", imageFile.Name); // Add the image file
            }

            // Add the updated post data as form fields
            formData.Add(new StringContent(updatedPost.Title), "Title");
            formData.Add(new StringContent(updatedPost.Content), "Content");

            // Optionally, add other fields
            formData.Add(new StringContent(updatedPost.UpdatedAt.ToString("o")), "UpdatedAt");

            // First, upload the image using the UploadFile endpoint
            if (imageFile != null && imageFile.Size > 0)
            {
                // var uploadResponse = await _httpClient.PostAsync("https://localhost:7154/api/Upload/UploadFile", formData);
                var uploadResponse = await _httpClient.PostAsync($"{_apiBaseUrl}/api/Upload/UploadFile", formData);


                if (uploadResponse.IsSuccessStatusCode)
                {
                    var fileName = await uploadResponse.Content.ReadAsStringAsync();
                    updatedPost.ImageFileName = fileName; // Set the uploaded file name
                }
                else
                {
                    var errorContent = await uploadResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error uploading file: {uploadResponse.StatusCode}, {errorContent}");
                }
            }

            // Now send the updated post data to the Posts endpoint
            // var postResponse = await _httpClient.PutAsJsonAsync($"https://localhost:7154/api/Posts/{id}", updatedPost);
            var postResponse = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/api/Posts/{id}", updatedPost);

            return postResponse;
        }


        // Delete a post
        public async Task<HttpResponseMessage> DeletePostAsync(int id)
        {
            // return await _httpClient.DeleteAsync($"https://localhost:7154/api/Posts/{id}");
            return await _httpClient.DeleteAsync($"{_apiBaseUrl}/api/Posts/{id}");
        }
    }
}
