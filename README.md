# SpartaMetaverse README

* * *

## 1. 개요

- 게임 입장 후, 로비 화면에서 미니 게임을 찾아서 진행한다.
- 미니 게임 내에서 장애물을 피해 최대한 오랜 시간동안 생존하는 것이 목표이다.
- ** Main 브런치 내 제가 구현한 기능들을 확인할 수 있습니다. ** 

### 게임 시퀀스 소개
- 로비 화면 → 미니 게임 포탈과의 트리거 충돌을 통해 미니 게임 입장 → 미니 게임 플레이 or 나가기를 눌러 로비 화면으로 되돌아온다.

* * *

## 2. Manager 객체 설명

### 2.1. LobbyManager | Scripts 폴더 → 1.LobbyScene 폴더 → Managers 폴더 → LobbyManager.cs 참조
- 로비 화면 내 각 객체별 데이터 전달을 담당하는 Manager.
- #### 해당 스크립트에 적용한 기능 상세 설명
  - #### Action 메서드
    ![image](https://github.com/user-attachments/assets/b009e802-d91c-4e45-a996-86d6ad635683)
    - 플레이어와 오브젝트 간 상호작용을 진행하기 위한 메서드
    - isAction이라는 bool 값 변수를 통해 플레이어와 오브젝트가 상호작용할 때, 플레이어의 행동을 제어한다.
      - 플레이어가 지정된 범위 내 오브젝트를 클릭했을 경우, isAction을 true로 처리한 후에 대화창 UI 생성 및 Talk 메서드를 통해 텍스트 데이터를 호출한다.
        - 이 때, 플레이어는 오브젝트와 상호작용을 완료할 때까지 이동할 수 없다. 
      - 플레이어가 오브젝트와의 상호작용을 완료했을 경우, isAction을 false로 처리한 후에 플레이어가 다시 이동할 수 있도록 구현했다.
        
  - #### Talk 메서드
    ![image](https://github.com/user-attachments/assets/05f086da-eb19-4f85-a4c6-4844ae85c93d)
    - 플레이어가 오브젝트와 상호작용을 진행할 시, Action 메서드를 통해 호출한다.
    - TalkManager을 통해 플레이어가 선택한 오브젝트에 적용된 텍스트 데이터를 호출하여 대화창 UI창에 출력한다.
    - Unity Editor 상에서 상호작용할 오브젝트 선정, 그리고 그 중에서 NPC 오브젝트를 선정한다.
      - NPC 오브젝트 선정의 경우, ObjectControl 스크립트를 통해 개발자가 임의로 선정할 수 있다. → 추후 NPC 객체 설명 시 상세 설명 예정. 
    - isNPC라는 bool 값 변수를 통해 NPC 오브젝트를 구분한 후, 적용된 텍스트 데이터를 호출한다.
      - 현재 스크립트 상에서는 NPC 여부와 상관없이 오브젝트 클릭 시에 지정한 텍스트 데이터를 호출한다.

---
     
### 2.2. TalkManager | Scripts 폴더 → 1.LobbyScene 폴더 → Managers 폴더 → TalkManager.cs 참조
- 플레이어와 오브젝트 간 상호작용 시, 출력되는 텍스트 데이터를 관리하는 Manager.
-  #### 해당 스크립트에 적용한 기능 상세 설명
  - #### GenerateData 메서드
    ![image](https://github.com/user-attachments/assets/cf20ffa4-571a-4fb0-ad6e-3f33c7182ebc)
    - Dictionary 자료형을 사용하여 각각의 오브젝트에 출력할 텍스트 데이터를 생성하는 메서드
    - ObjectControl 스크립트를 사용하여 각각의 오브젝트에 id값을 부여한 후, 오브젝트의 id에 따라 각각 다른 텍스트를 생성하도록 구현했다.
  - #### GetTalk 메서드
    ![image](https://github.com/user-attachments/assets/e97d5245-1b19-4b82-b2ae-c3d19f31a01d)
    - GenerateData 메서드에서 생성한 데이터들을 다른 곳에서 호출하기 위한 메서드
    - 해당 오브젝트들의 id값과 talkIndex를 매개변수로 받음으로써 플레이어가 클릭한 오브젝트의 id값에 따라 오브젝트를 구분한 후, 해당 오브젝트에 지정한 텍스트 데이터를 호출한다.
    - ** 해당 메서드의 경우, 각 오브젝트 별 2개 이상의 텍스트 데이터가 있을 경우를 대비하여 스크립트를 작업했다. **

---
   
### 2.3. UIManager | Scripts 폴더 → 1.LobbyScene 폴더 → Managers 폴더 → UIManager.cs 참조
![image](https://github.com/user-attachments/assets/eb2ca75d-11fd-4d8d-a0ab-6154e5413ee1)
![image](https://github.com/user-attachments/assets/5f051a2d-4105-4124-b86f-9e64e168f006)
- SpartaMetaverse 프로젝트 내 모든 UI들을 관리하는 Manager.
  - 프로젝트 내 들어갈 모든 UI들은 해당 매니저에 명시되며, UI의 생성 조건과 이벤트 등을 반드시 해당 매니저를 거쳐서 진행되도록 구현했다.
- 각 씬에 들어있는 UI들마다 생성 조건들을 설정한 후, 생성 조건을 만족한 UI들을 게임 화면에 띄우는 역할을 담당한다.
- #### 해당 스크립트에 적용한 기능 상세 설명 → UI별 생성 조건과 이벤트가 다르기 때문에 핵심 기능만을 설명한다.
  - #### ChangeState 메서드
    ![image](https://github.com/user-attachments/assets/ac727049-60a6-40ca-b6d5-3dfc13185867)
    - UI별 각각 설정한 생성 조건을 달성했을 때마다, 해당 메서드를 통해 UI의 SetActive를 true로 전환하는 메서드.
   
### 2.4. GameManager | Scripts 폴더 → 2. FlappyPlane 폴더 → Managers 폴더 → GameManager.cs 참조
- 미니 게임인 FlappyPlane 게임 내 객체 간 데이터를 전달을 담당하는 Manager.
- #### 해당 스크립트에 적용한 기능 상세 설명
  - #### AddScore 메서드
    ![image](https://github.com/user-attachments/assets/c39e96b1-fae1-4e05-8e4b-7db89ff640e6)
      - 게임 시작 후, 플레이어가 장애물을 넘어갈 때마다 1점씩 추가해주는 메서드.
      - UIManager에 추가되는 점수들의 데이터를 전달해준다.
  - #### RestartGame 메서드
    ![image](https://github.com/user-attachments/assets/98130bf2-6db0-4022-8d8a-03a9e1643d23)
    - 게임 종료 UI에서 플레이어가 [재시작] 버튼을 누를 경우, 해당 미니게임의 첫 화면으로 전환한다.

      
* * *
## 3. 화면 별 Hierarchy 내 구현 기능 설명

### 3.1. LobbyScene |  작업 브런치: LobbyScene
- 개요
  - 게임 시작 시, 플레이어가 최초로 진입하는 구간.
  - 해당 구간에서 NPC 외 오브젝트들을 마우스 클릭을 통해 상호작용을 진행할 수 있다.

#### 3.1.1 LobbyScene 내 기능 설명 
- #### Main Camera | Scripts 폴더 → 1.LobbyScene 폴더 → Entity 폴더 →  FallowCamera.cs 참조
  ![image](https://github.com/user-attachments/assets/467b336a-1e2d-4886-a36a-56433929c7b5)
  ![image](https://github.com/user-attachments/assets/905af020-30ee-45ac-a5c5-bae098e7e366)
  - 지정한 범위를 벗어나지 않은 채, 플레이어를 추적하여 비춰준다.
  - 해당 Inspector 창 내에서 Map Size를 Editor 상에서 수정하여 맵에 맞춰 카메라의 이동 제한 범위를 설정한다.
    - 우측 이미지에서 지정한 Map Size를 붉은 선의 Rect로 그리게 하여, 눈으로 확인할 수 있도록 구현했다.
  - Lerp 메서드를 활용하여 플레이어를 추적할 때 부드러운 움직임으로 추적하도록 구현했다.

--- 
 
- #### Player 객체 | Scripts 폴더 → 1.LobbyScene 폴더 → Entity 폴더 → PlayerControl.cs 참조
  ![image](https://github.com/user-attachments/assets/b9e68ae0-eeb9-424e-ba02-24d8f0aff7eb)
  ![image](https://github.com/user-attachments/assets/ece73294-bbf7-428d-9fa7-372fe7d0e707)
  - 로비 화면에서 플레이어가 조작하여 움직이는 캐릭터 객체.
  - W,A,S,D를 눌러 해당 캐릭터를 상,하,좌,우로 조작 가능하다.
  - 플레이어의 중심 좌표를 기준으로 마우스 커서의 위치에 따라 왼쪽, 오른쪽을 바라보도록 구현했다.

  - #### 오브젝트 상호작용 기능 추가: PlayerControl.cs → ScanObject 메서드
    ![image](https://github.com/user-attachments/assets/33807aad-1d70-480d-a86c-e29e9801c5b3)
    ![image](https://github.com/user-attachments/assets/f0abb015-9191-49f9-b122-134412a927bb)
    - 메서드 구현 의도: 플레이어와 일정 거리 내 존재하는 오브젝트를 클릭하여 상호작용할 수 있도록 하기 위함.
    - #### 메서드 상세 설명
        ![image](https://github.com/user-attachments/assets/f08b2e91-865e-4492-aebb-225ba3ea6277)
      - 플레이어와 마우스 커서 위치 사이 특정 거리를 지정한 후, 마우스 클릭 시에 특정 거리 내에 오브젝트가 존재한다면, 해당 오브젝트에 적용한 상호작용 이벤트를 실행한다.
        - ##### 오브젝트 판단 처리 로직
          - Unity Editor → 객체마다 [Object] Layer를 지정하여 게임 내 플레이어와 상호작용할 오브젝트들을 구성한다.
          - 스크립트 상에서 RayHit 메서드를 사용하여, 마우스 클릭 시에 특정 거리를 그리는 Ray와 충돌한 오브젝트가 [Object] Layer로 지정되어 있다면, scanObject에 해당 오브젝트의 정보를 넣는다.
          - 만약, [Object] Layer로 지정되어 있지 않은 오브젝트의 경우, scanObject를 null로 처리하여 콘솔 창에 NullReferenceException 에러를 띄운다.
         
  - 오브젝트와 상호작용 진행 시, 플레이어의 모든 행동을 막으며, 상호작용을 종료한 후, 다시 행동을 진행할 수 있다.
    - LobbyManager 설명 참고.

---

- #### FlappyPlanePortal 객체 | Scripts 폴더 → 1.LobbyScene 폴더 → Entity 폴더 → GoToFlappyScene.cs 참조
  ![image](https://github.com/user-attachments/assets/bd355368-c2d3-423d-b843-06594af32f6f)
  ![image](https://github.com/user-attachments/assets/0e32f9d9-a621-420b-a15e-f9f756bba6aa)
  - 플레이어와 충돌 시, 미니 게임으로 이동할지 여부를 묻는 UI창을 생성하는 객체
    - [네] 버튼을 눌러 미니 게임 씬으로 전환한다.
    - [아니오] 버튼을 눌러 해당 UI를 종료한다.

---

- #### LobbyScene 내 UI 설명
  - #### MiniGameUI
    ![image](https://github.com/user-attachments/assets/715a1b3a-4995-4a9a-a15a-475799bfc031)
    ![image](https://github.com/user-attachments/assets/8ed03107-5714-4acf-9033-373efccfe918)
    - FlappyPlanePortal 객체 설명 참고
      
  - #### DialogueUI | 작업 브런치: NPC 브런치
    - ** 프로젝트 시작 전, 반드시 해당 UI를 킨 상태로 진행해야 게임 내에서 적용이 됩니다. **
    ![image](https://github.com/user-attachments/assets/2127bab3-cecd-46f9-983d-4518e8704b83)
    ![image](https://github.com/user-attachments/assets/f0cd426d-6101-4e45-8aa0-85be22d22216)
    ![image](https://github.com/user-attachments/assets/1cf17f1a-f749-4de9-a4ec-b749406bf5ef)
    ![image](https://github.com/user-attachments/assets/4f798709-22f1-4eec-9282-fbe304f1a29e)
    - 게임 내 플레이어가 오브젝트와 상호작용 진행 시, 생성되는 대화창 UI.
    - 대화창 UI 생성 시, 플레이어의 모든 행동이 불가하다.
    - 화면 내 다른 곳을 클릭하여 대화창 UI 닫기 및 플레이어가 다시 행동을 진행할 수 있도록 구현했다.
    - 대화 텍스트 생성 로직 → LobbyManager, TalkManager 설명 참고.

---
- #### 게임 내 오브젝트 구성 | 작업 브런치: NPC 브런치
  ![image](https://github.com/user-attachments/assets/c3001482-2d50-4842-b246-0a5c7830db32)
  ![image](https://github.com/user-attachments/assets/ff8f160f-2356-4ad0-8066-b3e590937687)
  - 로비 씬 내 NPC를 포함한 오브젝트들 배치 및 플레이어가 클릭할 시에 해당 오브젝트에 저장된 텍스트 데이터를 출력한다.
    ![image](https://github.com/user-attachments/assets/a6edcf62-da4b-4794-a461-98f764fbd6f0)
  - ObjectControl 스크립트를 적용하여 각각의 오브젝트에 id값을 부여하고, NPC로 지정하고자 하는 오브젝트들을 Unity Editor 상에서 지정할 수 있도록 구현했다.
  - 모든 오브젝트에 Box Collider와 Rigidbody를 적용하여 플레이어 → ScanObject 메서드에 들어간 RayHit를 적용하도록 구현했다.
 
* * *

### 3.2. FlappyPlaneScene |  작업 브런치: MiniGame-FlappyPlane 브런치
- #### 미니 게임 개요
  - 플레이어가 LobbyScene에서 FlappyPlanePortal과 충돌 후, 생성된 UI에서 [예] 버튼을 눌렀을 경우 전환되는 게임 씬.
  - 게임 목표: 최대한 오랜 시간동안 장애물을 피해가며 생존하는 형식의 게임.
  - 게임 종료 후, 최고 점수를 확인할 수 있으며, 이를 갱신하는 재미를 가진 게임.

- #### Main Camera | Scripts 폴더 → 2. FlappyPlane 폴더 → Entity 폴더 → FlappyPlaneCamera.cs 참조
  ![image](https://github.com/user-attachments/assets/efe2b249-c87a-4fb8-b37c-9e8081f506d4)
  - 플레이어의 x축 변화에 따라 따라다니도록 구현했다.
  
- #### Player 객체 | Scripts 폴더 → 2. FlappyPlane 폴더 → Entity 폴더 → Player.cs 참조
  ![image](https://github.com/user-attachments/assets/4d80455f-7c5c-4ebb-8e72-9eb1c57f04df)
  - 게임 내, 마우스 클릭을 통해서 중력의 힘을 받아 떨어지려는 플레이어를 점프시켜 떨어지지 않게 구현했다.
  - LobbyScene → FlappyPlaneScene으로 전환된 후, 자동으로 떨어지는 것을 방지하고자, 게임 시작 UI에서 [시작] 버튼을 누를 때까지 플레이어에게 적용되는 중력값과 이동 값을 0으로 설정했다.
  - 이외 나머지 부분의 경우, 강의 영상에서 구현한 대로 적용했다.
  
- #### Environments 객체
  - 강의 영상에서 구현한 대로 적용했다.
  - 이외 추가적인 구현은 없다.

- #### Obstacle 객체  | Scripts 폴더 → 2. FlappyPlane 폴더 → Entity 폴더 → Obstacle.cs 참조
  - 강의 영상에서 구현한 대로 적용했다.
  - 이외 추가적인 구현은 없다.
 
- #### GameManager 객체  | Scripts 폴더 → 2. FlappyPlane 폴더 → Managers 폴더 → GameManager.cs 참조
  - 2. Manager 객체 설명 → 2.4. GameManager 설명 부분 참고.
  - 이외 추가적인 구현 사항은 없다.

- #### UI 객체  | Scripts 폴더 → 2. FlappyPlane 폴더 → UIs 폴더 참조
  ![image](https://github.com/user-attachments/assets/39231639-f150-42cc-a0c7-122e1cdd07a1)
  ![image](https://github.com/user-attachments/assets/46c88498-804f-4855-9ec7-e29bc3336545)
  - HomeUI: 게임 시 생성되는 UI. 기존 강의 영상에서 나온 부분에 게임에 대한 설명 부분만 추가하였다.
    - [시작] 버튼을 누르기 전까지 플레이어의 이동을 제한한다.
    - [나가기] 버튼을 눌러 LobbyScene으로 전환한다.
  - GameUI: 게임 진행 중, 화면 상단 부분에 플레이어가 장애물 구간을 지날 때마다 점수를 추가하여 적용한다.
    - 강의 영상에서 나온대로 적용했으며, 이외 추가적인 구현 사항은 없다.
  - GameOverUI: 플레이어가 장애물에 부딪히거나 땅에 떨어졌을 시, 플레이어 사망 처리 및 해당 UI를 생성하여 게임 내 플레이어가 기록한 점수를 출력한다.
    - 최고 점수도 명시하여 플레이어가 이를 통해 최고 점수를 갱신하며 진행할 수 있도록 구현했다.
    - 강의 영상에서 나온대로 적용했으며, 이외 추가적인 구현 사항은 없다.
