using System;

public class TV
{
    public void On()
    {
        Console.WriteLine("TV is On");
    }

    public void Off()
    {
        Console.WriteLine("TV is Off");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine($"TV channel set to {channel}");
    }
}

public class AudioSystem
{
    public void On()
    {
        Console.WriteLine("Audio System is On");
    }

    public void Off()
    {
        Console.WriteLine("Audio System is Off");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"Audio System volume set to {volume}");
    }
}

public class DVDPlayer
{
    public void Play()
    {
        Console.WriteLine("DVD is playing");
    }

    public void Pause()
    {
        Console.WriteLine("DVD is paused");
    }

    public void Stop()
    {
        Console.WriteLine("DVD is stopped");
    }
}

public class GameConsole
{
    public void On()
    {
        Console.WriteLine("Game Console is On");
    }

    public void StartGame(string game)
    {
        Console.WriteLine($"Game '{game}' is starting");
    }
}

public class HomeTheaterFacade
{
    private TV _tv;
    private AudioSystem _audioSystem;
    private DVDPlayer _dvdPlayer;
    private GameConsole _gameConsole;

    public HomeTheaterFacade(TV tv, AudioSystem audioSystem, DVDPlayer dvdPlayer, GameConsole gameConsole)
    {
        _tv = tv;
        _audioSystem = audioSystem;
        _dvdPlayer = dvdPlayer;
        _gameConsole = gameConsole;
    }

    public void WatchMovie()
    {
        Console.WriteLine("Preparing to watch a movie...");
        _tv.On();
        _audioSystem.On();
        _dvdPlayer.Play();
    }

    public void StopMovie()
    {
        Console.WriteLine("Stopping movie...");
        _dvdPlayer.Stop();
        _tv.Off();
        _audioSystem.Off();
    }

    public void PlayGame(string game)
    {
        Console.WriteLine("Preparing to play a game...");
        _gameConsole.On();
        _gameConsole.StartGame(game);
    }

    public void ListenToMusic()
    {
        Console.WriteLine("Preparing to listen to music...");
        _tv.On();
        _audioSystem.On();
    }

    public void TurnOffSystem()
    {
        Console.WriteLine("Turning off the system...");
        _tv.Off();
        _audioSystem.Off();
        _dvdPlayer.Stop();
        _gameConsole.On(); // Assuming turning off console is same as starting it for the sake of demonstration
    }

    public void SetVolume(int volume)
    {
        _audioSystem.SetVolume(volume);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TV tv = new TV();
        AudioSystem audioSystem = new AudioSystem();
        DVDPlayer dvdPlayer = new DVDPlayer();
        GameConsole gameConsole = new GameConsole();

        HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audioSystem, dvdPlayer, gameConsole);

        homeTheater.WatchMovie();
        homeTheater.SetVolume(20);
        homeTheater.StopMovie();

        homeTheater.PlayGame("The Legend of Zelda");
        homeTheater.TurnOffSystem();

        homeTheater.ListenToMusic();
        homeTheater.SetVolume(15);
    }
}
