# Winform-Remopipe
Automatic removal system in Pipe에서 RemoPipe로 차용

# 센서정의
**압력센서**

측정범위 0-1Mpa, 1-5V 출력, 24V 전원
물이 들어가는 곳의 압력센서를 Inlet Flow, 거름망을 통과해 나가는 곳의 압력센서를 Oulet Flow 라 함 

**솔레노이드 밸브**

HPW2170 (상시닫힘형)
Normal Close (N.C.), 24V 전원

# 기능정의
**Sol V/V 시퀀스**

Sol V/V 의 Open 시 중력을 이용 순간 배수를 통해 효과를 높여야 하므로 모든 시퀀스에서 V/V 의 Valve open time (vot_val) 을 Variable 로 가져가되 open-close 구간 간 최소 단위는 1000ms (1-sec) 로 한다. (H/W 인 V/V 는 ms 단위로 정확히 동작시킬 수 없기 때문)

**배수 효율 시퀀스**

배수 명령이 시작되고 순간 배수 효과 증가를 위해 1초 (val) 간 솔밸브를 열 고 닫은 뒤 1초(val) 딜레이를 준 후 다시 1초 열어주는 식의 자동차 ABS 와 같은 방식의 배수 시퀀스를 가진다
고정배수와 조건배수시 모두 배수 효율 시퀀스를 별도의 변수를 가져가며
Val_EFF_OpenTime(msec), Val_EFF_DelayTime(msec), Val_EFF_Roop(num)

# 시퀀스 다이어그램
<img width="557" alt="image" src="https://github.com/2YeongHoon/Winform-Remopipe/assets/24671803/0efbf375-b6c9-4956-80cd-4a483065f4cd">

# UI
<img width="557" alt="image" src="https://github.com/2YeongHoon/Winform-Remopipe/assets/24671803/f6300d1d-af68-4bc8-97ce-6d16e2a37d8a">
<img width="557" alt="image" src="https://github.com/2YeongHoon/Winform-Remopipe/assets/24671803/1ed427ad-f36b-42df-a8a2-07b45a78f0a3">
<img width="557" alt="image" src="https://github.com/2YeongHoon/Winform-Remopipe/assets/24671803/44e9950a-dd4c-4c5c-bb58-1305ff3dbf19">
<img width="577" alt="image" src="https://github.com/2YeongHoon/Winform-Remopipe/assets/24671803/fb5942a7-5a1c-4b40-a6d3-7cc850c62fc1">

# 하드웨어
<img width="600" alt="image" src="https://github.com/2YeongHoon/Winform-Remopipe/assets/24671803/155ee788-1f03-40ce-90f3-b4a1fcc34292">


**COM port (Male)** : 터치모니터 와 컨트롤러 간의 Serial 통신 연결 용도

**케이블** : D-SUB 9 pin (1:1) male (monitor) to female (controller, 위 COM port 와 연결)

**FLOW_IN 12CH** : 1채널 - 물이 들어오는 파이프에 설치될 압력센서와 연결 + 2채널 - 물이 나가는 파이프에 설치될 압력센서와 연결센서에서 사용할 24V 전원 공급 및 신호 핀

**SOL_OUT** : 솔레노이브 밸브와 연결 Sol V/V 에서 사용할 24V 전원 공급 (신호 핀 별도 없이 전원 공급-비공급 으로 제어)
