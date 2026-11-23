public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> index = new Dictionary<int, int>();

        for(int i=0; i<nums.Length; i++){
            index[nums[i]] = i;
        }

        for(int i=0; i<nums.Length; i++){
            int diff = target - nums[i];
            if(index.ContainsKey(diff) && index[diff] != i)
                return new int[] {i ,index[diff]};
        }

        return new int[0];
    }
}
