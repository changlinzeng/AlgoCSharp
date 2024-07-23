public class NumberOfDiceRollsWithTargetSum_1155 {
    public static int NumRollsToTarget(int n, int k, int target) {
        return Dfs(n, k, target, new Dictionary<string, int>());
    }

    private static int Dfs(in int n, in int k, in int target, in Dictionary<string, int> memo)
    {
        if (target == 0 && n == 0)
        {
            return 1;
        }
        if (target == 0 || n == 0)
        {
            return 0;
        }
        var key = $"{n}_{target}";
        if (memo.ContainsKey(key))
        {
            return memo[key];
        }
        for (var i = 1; i <= k; i++)
        {
            if (target >= i)
            {
                var count = Dfs(n - 1, k, target - i, memo);
                memo.TryAdd(key, 0);
                memo[key] = (memo[key] + count) % 1_000_000_007;
            }
        }
        return memo[key];
    }
}