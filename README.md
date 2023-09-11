# ColorTilePuzzle
タイルの無い場所をクリックし、上下左右で一番近いタイルの中に同じ色の組み合わせがあればスコアが加算(タイルを消す)される。   
組み合わせがない場合は、スコアが減算または残りタイムが減少する。

# 制作環境
Unity 2021.3.29f1

# 制作テーマと注意事項
・テーマ：「交わる」   
・制作期間は1ヵ月(9/30まで)   
・いくつかのデザインパターンを用いた開発とする   

# 仕様書
・画面タイルは縦12マス x 横24マスとする。   
・画面左上にタイム、右上にスコアを表示する。  
・タイルの色の種類は赤、緑、青、黄、ピンク、オレンジ、シアン、グレー、ブラウン、紫の10種類。   
・タイムは2分。 
・タイトル画面のPlayボタンを押した瞬間からゲームスタート、タイマーもスタートする。  
・タイマーが0になったらゲームオーバー画面を表示する。  
　ゲームオーバー画面はスコアとRetryボタンを表示し、Retryボタンを押すと最初からゲームを開始する。  
・タイルの無い場所のみクリックできる。タイルのある場所はクリックできない。   
・タイルの無い場所をクリックした際、クリックした場所から上下左右の一番近いタイルを取得し、   
　同じ色の組み合わせがあればスコアを加算してタイルを消す。  
　取得した上下左右のタイルの中に同じ色の組み合わせが無ければタイムを10秒減少させる。
・スコアは消したタイル1つにつき1点。2つなら2点、3つなら3点、最大の4つなら4点。  
・連続で消した場合はコンボ表示を行い、スコアにコンボボーナスをつける(2連続は2倍、3連続は3倍、4連続は4倍...)  
　ただし、消せなかった場合はコンボボーナスをリセットする(初期値は1倍)
  
# 使用したデザインパターン
・Singleton  
・Action
