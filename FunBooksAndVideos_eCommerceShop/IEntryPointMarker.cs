namespace FunBooksAndVideos_eCommerceShop;

/// <summary>
/// Entry Point marker for integration tests.
/// This interface is needed for WebApplicationFactory<EntryPoint> class
/// In order to inherit a public class from this factory, public member 'EntryPoint' must be provided
/// because Program.cs is internal by default
/// </summary>
public interface IEntryPointMarker
{
}
