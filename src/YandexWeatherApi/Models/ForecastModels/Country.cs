﻿using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Country
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }
}