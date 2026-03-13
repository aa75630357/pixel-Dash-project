Pixel Dash Project 2D
這是一款強調「高速位移」與「精準碰撞」的 2D 橫向捲軸遊戲原型。

📂 專案架構導覽 (Project Structure)
為了方便閱讀，以下是本專案的主要檔案分佈：

Assets/ - 專案核心資源

Scripts/ ⬅️ 面試官請看這！ 所有的 C# 邏輯都在這裡。

PlayerController.cs: 處理玩家輸入、移動與衝刺邏輯。

GameManager.cs: 管理遊戲狀態（得分、死亡重新開始）。

CameraFollow.cs: 實現平滑的鏡頭追蹤系統。

Scenes/ - 遊戲場景檔，包含主要關卡配置。

Sprites/ - 遊戲使用的 2D 像素美術素材。

Prefabs/ - 預製物件，包含玩家角色、障礙物與特效。

ProjectSettings/ - Unity 專案的物理、輸入與標籤設定。

🛠 核心技術實作內容
我在這個專案中重點解決了以下技術挑戰：

1. 位移系統 (Dash & Movement)
解決方案： 使用 Rigidbody2D.velocity 搭配 Coroutine 實作非同步的衝刺 (Dash) 機制。

優化： 加入了「衝刺冷卻時間」與「殘影特效」，提升操作的視覺反饋。

2. 精確的碰撞偵測
技術： 使用 BoxCollider2D 搭配自定義的 LayerMask 進行地面判定。

QA 思維： 透過代碼預防了「角落抖動 (Corner Jitter)」與「牆面摩擦力掛勾」等 2D 遊戲常見的 Bug。

3. 動態攝影機
實現： 使用 Lerp 演算法確保攝影機在角色高速衝刺時仍能保持平滑跟隨，不產生畫面閃爍。
