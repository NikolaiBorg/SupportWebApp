using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SupportWebApp.Models;

public class SupportMessage
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Navn skal udfyldes")]
    [JsonProperty(PropertyName = "navn")]
    public string Navn { get; set; } = "";

    [Required(ErrorMessage = "Email skal udfyldes")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig email")]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Telefonnummer skal udfyldes")]
    [JsonProperty(PropertyName = "telefon")]
    public string Telefon { get; set; } = "";

    [Required(ErrorMessage = "Beskrivelse skal udfyldes")]
    [JsonProperty(PropertyName = "beskrivelse")]
    public string Beskrivelse { get; set; } = "";

    [Required(ErrorMessage = "Kategori skal vælges")]
    [JsonProperty(PropertyName = "category")]
    public string Category { get; set; } = "";

    [JsonProperty(PropertyName = "datoTidspunkt")]
    public DateTime DatoTidspunkt { get; set; } = DateTime.UtcNow;
}