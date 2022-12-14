namespace Model.Business.Entries
{
    public abstract class Entry : IEquatable<Entry>
    {
        private static EntryComparer? _comparer;
        private static EntryComparer Comparer => _comparer ??= new EntryComparer();

        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Uid { get; init; }

        /// <summary>
        /// Login's app
        /// It can be nickname, email,...
        /// </summary>
        public string Login { get; protected set; }

        /// <summary>
        /// Password used on the app.
        /// </summary>
        public string Password { get; protected set; }

        /// <summary>
        /// Password's App/Website
        /// </summary>
        public string App { get; protected set; }

        /// <summary>
        /// Label 
        /// </summary>
        public string Label
        {
            get => $"{App} - {Login}";
        }

        /// <summary>
        /// Note about the entry.
        /// </summary>
        public string? Note { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="app"></param>
        /// <param name="note"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected Entry(Guid uid, string login, string password, string app, string? note)
        {
            if(uid == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(uid));
            }
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (string.IsNullOrEmpty(app))
            {
                throw new ArgumentNullException(nameof(app));
            }

            Uid = uid;
            Login = login;
            Password = password;
            App = app;
            Note = note ?? string.Empty;
        }

        public virtual bool Equals(Entry? other) => Comparer.Equals(this, other);

        public override bool Equals(object? obj)
            => obj is Entry entry && Comparer.Equals(this, entry);

        public override int GetHashCode() => Comparer.GetHashCode(this);
    }
}
