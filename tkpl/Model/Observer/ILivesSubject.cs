namespace tkpl.Model.Observer
{
    /// <summary>
    /// Subject (Publisher) interface untuk Observer Pattern.
    /// Mendeklarasikan mekanisme subscription: mendaftarkan, menghapus,
    /// dan memberitahu observer saat terjadi perubahan state.
    /// Ref: https://refactoring.guru/design-patterns/observer
    /// </summary>
    public interface ILivesSubject
    {
        void Subscribe(ILivesObserver observer);
        void Unsubscribe(ILivesObserver observer);
        void NotifyObservers();
    }
}
