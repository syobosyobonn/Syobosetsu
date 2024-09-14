# パスワード認証ソースコード(jp)
## 概要
Syobosetsu/Updater で使用しているパスワード認証のソース及びそれのサンプルです<br>
> [!WARNING]
> このソース、サンプルを利用したことにおけるいかなる損害においても<br>
> 制作者は責任を負いません<br>
<br>
対象はVS2022です。

## 特徴
以下のメリット、デメリットがあります<br>
```diff
+ 逆コンパイルされた際に、パスワードがわからない。
- 素人が作成したものなので、コードが怪しい。
```

## 仕組み
大まかな仕組みは以下の通りです<br>
1. (インストール)逆コンパイルが不可能なVisualStudioSetupProjectを使用し、"Key"と"Check"のレジストリキーをセットする
2. (チェック)KeyをCheckで暗号化し、暗号化された内容を検証する。
詳細はサンプルのコードをご覧ください。

## サンプル説明
### PathAuthenticationSample
レジストリに保存する値をセットするものです。<br>
**認証のテキストボックスは省略しています。** <br>
**実際に実装する場合は設定の変更が必要です。**

### GenCheckValue
CheckValueを生成します。ランダムです。<br>
**実際に実装する場合は変数の変更が必要です。**

### TestEncryption
期待される結果を生成します。<br>
**実際に実装する場合は変数の変更が必要です。**

### PathAuthentication
KeyとCheckを基に検証します。<br>
**実際に実装する場合は変数の変更が必要です。**


# Pathword Authentication source code(en)
> [!WARNING]
> Main language is Japanese.
> Plese use translator by the case.

## Overview
This is Syobosetsu/Updater's password authentication sources and sample of it <br>
> [!WARNING]
> The producer is not liable for any damage whatsoever in connection with the use of this source or sample<br>
<br>
These is for VS2022.

## Features
These have This Advantages and disadvantages.↓<br>
```diff
+ Can't look password at re-compile.
- The code is difficult to understand as it was created by an amateur.
```

## Structure
The general scheme is as follows:<br> 
1. (Installation) Use VisualStudioSetupProject, which cannot be decompiled, and set the registry keys of “Key” and “Check”. 
2. (Check)Encrypt “Key” with “Check” and verify the encrypted contents.
If you wanna details ,See the sample code.

## Sample Description
### PathAuthenticationSample
Setting value for reg.<br>
**Authentication text boxes are omitted.** <br>
**Actual implementation requires changes to the configuration.**

### GenCheckValue
Generate "CheckValue". It's random.<br>
**Actual implementation requires changing variables.**

### TestEncryption
Generates expected results.<br>
**Actual implementation requires changing variables.**

### PathAuthentication
Verification based on “Key” and “Check".<br>
**Actual implementation requires changing variables.**
