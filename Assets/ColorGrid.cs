using UnityEngine;
using UnityEngine.UI;

public class ColorGrid : MonoBehaviour
{
    public Image[] leftGridImages;   // 左側のグリッド（正しい色）
    public Image[] rightGridImages;  // 右側のグリッド（1つだけ間違い）

    private Color[,] colors = new Color[3, 3] {
        { Color.cyan, Color.green, Color.black },
        { Color.yellow, Color.red, Color.cyan },
        { Color.green, new Color(1f, 0.75f, 0.8f), Color.magenta }
    };

    private int correctIndex; // 間違いの位置（正解）

    void Start()
    {
        // 左側に元の色を表示
        ApplyColors(leftGridImages, colors);

        // 色データをコピーして右側用に使う
        Color[,] rightColors = (Color[,])colors.Clone();

        // ランダムに1つだけ色を変える位置を決定
        correctIndex = Random.Range(0, 9);
        int row = correctIndex / 3;
        int col = correctIndex % 3;

        // 色を変える（例：Color.gray）
        rightColors[row, col] = Color.gray;

        // 右側に色を表示
        ApplyColors(rightGridImages, rightColors);
    }

    void ApplyColors(Image[] gridImages, Color[,] colorData)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;
                gridImages[index].color = colorData[i, j];
            }
        }
    }

    public void OnCellClicked(int index)
    {
        if (index == correctIndex)
        {
            Debug.Log("正解！");
            // ここに正解時の演出を追加可能（音・アニメーションなど）
        }
        else
        {
            Debug.Log("不正解！");
        }
    }
}
