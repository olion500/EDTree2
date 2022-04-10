# EDTree2

## Project Sturcture
### EDTree
- 데이터를 받아 방정식과 도형을 계산하는 라이브러리.
- `FittingLine` : 주어진 X,Y 데이터를 가지고 Least-Square 방식으로 2차/3차 방정식으로 만든다.
- `FittingEllipse` : 주어진 방정식 사이에 그려지는 타원을 만든다. 리턴값은 `EllipsePoint`.
- `FittingRect` : 주어진 방정식 사이에 그려지는 사각형을 만든다. 리턴값은 `RectPoint`.

### EDTreeWinform
- 데이터를 파일로 받아 읽고, 화면에 그래프를 그려주는 모듈.
- `ChartSettingsForm` : 사용자가 설정하는 옵션을 받아 처리하는 폼.
- `MainForm` : 설정한 옵션으로 그래프를 그리고 보여주는 폼.
  - `MainForm` : 파일 입출력, 화면 전환 등을 처리한다.
  - `MainFormChartDrawing` : 그래프 화면에 어떤 데이터를 가지고 처리할지 정한다.
  - `MainFormListViewDrawing` : 데이터 화면에 데이터를 어떻게 보여줄지 처리한다.


## Algorithm
### Maximum-Size Rectangle
- 두개의 방정식과 `X`값의 최대, 최소값을 가지고 최대 넓이가 되는 사각형을 구하기.
- 두개의 방정식 중 임의의 x에 대해 위에 위치한 방정식을 `UpperLine`, 아래 위치한 방정식을 `LowerLine` 이라고 한다.
- `X` 값의 최소값을 `minX`, 최대값을 `maxX`라고 한다.

1. 사격형의 `bottom`은 `LowerLine`의 `maximum` 값이다.
2. 사격형의 `left`는 임의의 변수 `t`이라고 한다. `minX` 에서 `maxX` 까지 변화한다. (변화는 0.01씩 더해지도록 했다)
3. 사각형의 `top`은 `UpperLine` 방정식에 `t` 를 넣은 값이다.
4. 사각형의 `right`는 `UpperLine` 방정식의 값이 `t`인 `x`값들이다. (`UpperLine` 방정식의 역함수에 `t`를 대입한 값)
5. `right` 에 해당하는 `x`값은 여러개가 나오는데 이중에서 최소값과 최대값만 가지고 사각형을 만들었다.
6. 임의의 변수 `t`를 `minX` 에서 `maxX` 까지 0.01씩 더하면서 사각형의 넓이가 최대가 되는 사각형을 찾는다.
7. `x`의 범위가 너무 작거나, `Abs(top - bottom)` 이 너무 작을경우, 의미있는 사각형이 안만들어지기 때문에 `tolerance`값보다 작으면 사각형을 찾이 못한겻으로 처리했다.


### Maximum-Size Ellipse
- 두개의 방정식과 `X`값의 최대, 최소값을 가지고 최대 넓이가 되는 타원을 구하기.
- 두개의 방정식 중 임의의 x에 대해 위에 위치한 방정식을 `UpperLine`, 아래 위치한 방정식을 `LowerLine` 이라고 한다.
- `X` 값의 최소값을 `minX`, 최대값을 `maxX`라고 한다.
- 타원이 방정식보다 작은지 판단하는 함수를 `IsEllipseBelowOfFittingLine` 이라고 한다. (방정식의 임의의 점이 방정식보다 작은지 판단한다.)

1. 타원의 `bottom`은 `LowerLine`의 `maximum` 값이다.
2. 임의의 변수 `l`, `r`을 설정한다. 각각 타원의 `left`, `right` 값이다.
3. 타원의 `top`은 `IsEllipseBelowOfFittingLine`이 `true` 일때까지 최대한으로 높인다.
4. `l`, `top`, `r`, `bottom` 으로 사각형을 그리고 그 안에 그려지는 타원을 구한다.
5. `l`과 `r`을 각각 `minX`, `maxX` 에서 서로 좁혀가며 1~4를 반복하고 최대 넓이의 타원을 구한다. (좁혀가는 값은 0.01로 설정했다)
