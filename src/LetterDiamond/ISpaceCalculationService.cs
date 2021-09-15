/// <summary>
/// The space calculation service interface.
/// </summary>
public interface ISpaceCalculationService
{
    /// <summary>
    /// Calculate the offset required for the specified letter and row that it is targeting.
    /// </summary>
    /// <param name="letter">The selected letter.</param>
    /// <param name="row">The target letter row.</param>
    /// <returns>The offset number.</returns>
    int OffSet(char letter, char row);

    /// <summary>
    /// Calculate the gap required between the characters on the target row.
    /// </summary>
    /// <param name="row">The target letter row.</param>
    /// <returns>The gap value.</returns>
    int Gap(char row);
}