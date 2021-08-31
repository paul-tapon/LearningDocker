namespace DOTR.QLess.Infrastructure.Services
{
    /// <summary>
    /// Container for password hash and salt and iterations.
    /// </summary>
    public sealed class PasswordHashContainer
    {
        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        public byte[] HashedPassword { get; private set; }
        /// <summary>
        /// Gets the salt.
        /// </summary>
        public byte[] Salt { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordHashContainer" /> class.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="salt">The salt.</param>
        public PasswordHashContainer(byte[] hashedPassword, byte[] salt)
        {
            this.HashedPassword = hashedPassword;
            this.Salt = salt;
        }
    }
}
