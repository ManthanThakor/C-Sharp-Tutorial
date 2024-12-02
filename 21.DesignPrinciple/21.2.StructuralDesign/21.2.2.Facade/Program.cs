using System;

public class TV
{
    public void TurnOn() => Console.WriteLine("TV is turned on.");
    public void TurnOff() => Console.WriteLine("TV is turned off.");
}

public class SoundSystem
{
    public void SetVolume(int level) => Console.WriteLine($"Sound system volume set to {level}.");
    public void TurnOn() => Console.WriteLine("Sound system is turned on.");
    public void TurnOff() => Console.WriteLine("Sound system is turned off.");
}

public class StreamingService
{
    public void StartStreaming(string movie) => Console.WriteLine($"Streaming {movie}...");
    public void StopStreaming() => Console.WriteLine("Streaming stopped.");
}

public class HomeTheaterFacade
{
    private readonly TV _tv = new TV();
    private readonly SoundSystem _soundSystem = new SoundSystem();
    private readonly StreamingService _streamingService = new StreamingService();

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Getting ready to watch a movie...");
        _tv.TurnOn();
        _soundSystem.TurnOn();
        _soundSystem.SetVolume(15);
        _streamingService.StartStreaming(movie);
        Console.WriteLine("Enjoy your movie!");
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater...");
        _streamingService.StopStreaming();
        _soundSystem.TurnOff();
        _tv.TurnOff();
    }
}

class Program
{
    static void Main()
    {
        HomeTheaterFacade homeTheater = new HomeTheaterFacade();
        homeTheater.WatchMovie("Inception");
        Console.WriteLine();
        homeTheater.EndMovie();
    }
}
