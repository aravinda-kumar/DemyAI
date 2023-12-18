namespace DemyAI.Helpers;

public class LocationHelper {

    public static async Task<string> GetMyLocationAsync() {

        var location = await Geolocation.GetLastKnownLocationAsync() ??
            await Geolocation.GetLocationAsync(new GeolocationRequest() {

                DesiredAccuracy = GeolocationAccuracy.Best,
                Timeout = TimeSpan.FromSeconds(30)

            });

        if(location is null) {

            await Console.Out.WriteLineAsync("Error!");

        }

        var CurrentAdress = await GetGeocodeReverseData(location!.Latitude, location!.Longitude);

        return CurrentAdress;
    }

    public static async Task<string> GetGeocodeReverseData(double latitude, double longitude) {
        IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

        Placemark? placemark = placemarks?.FirstOrDefault();

        return $"{placemark!.FeatureName} {placemark.CountryName} {placemark.PostalCode}";

    }
}
