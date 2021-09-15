/// <summary>
/// The space calculation service implementation.
/// </summary>
public class SpaceCalculationService : ISpaceCalculationService
{
    /// <inheritdoc />
    public int OffSet(char letter, char row)
    {
        var index = letter.GetIndex();

        index -= row.GetIndex();

        // todo: check for less than zero

        return index;
    }

    /// <inheritdoc />
    public int Gap(char row)
    {
        // zero indexed row count; B is 1
        var rowCount = row.GetIndex();

        if (rowCount > 0)
        {
            return rowCount + (rowCount - 1);
        }

        return rowCount;
    }
}