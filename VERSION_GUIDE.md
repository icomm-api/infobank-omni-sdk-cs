# 버전 관리 가이드

이 프로젝트는 Git 태그를 사용하여 버전을 관리하고 NuGet 패키지를 배포합니다.

## 버전 형식

-   **시맨틱 버전링** 사용: `MAJOR.MINOR.PATCH`
-   **태그 형식**: `v1.0.0`, `v2.1.3`, `v1.0.0-beta.1` 등

## 버전 증가 규칙

### MAJOR 버전 (주 버전)

-   호환되지 않는 API 변경
-   기존 기능 제거
-   주요 아키텍처 변경

### MINOR 버전 (부 버전)

-   새로운 기능 추가
-   기존 기능 개선
-   하위 호환성 유지

### PATCH 버전 (패치 버전)

-   버그 수정
-   성능 개선
-   문서 업데이트

## 배포 방법

### 1. 새 버전 태그 생성

```bash
# 로컬에서 태그 생성
git tag v1.0.0

# 태그 푸시
git push origin v1.0.0
```

### 2. GitHub에서 태그 생성

1. GitHub 저장소 → **Releases** → **Create a new release**
2. **Tag version** 입력: `v1.0.0`
3. **Release title** 입력: `Version 1.0.0`
4. **Description** 작성 (선택사항)
5. **Publish release** 클릭

### 3. 자동 배포

태그가 푸시되면 GitHub Actions가 자동으로:

1. 태그에서 버전 추출
2. 프로젝트 파일의 버전 업데이트
3. 빌드 및 테스트 실행
4. NuGet 패키지 생성
5. NuGet.org에 배포

## 버전 예시

### 정식 릴리즈

```bash
git tag v1.0.0
git push origin v1.0.0
```

### 베타 릴리즈

```bash
git tag v1.0.0-beta.1
git push origin v1.0.0-beta.1
```

### 알파 릴리즈

```bash
git tag v1.0.0-alpha.1
git push origin v1.0.0-alpha.1
```

### RC (Release Candidate)

```bash
git tag v1.0.0-rc.1
git push origin v1.0.0-rc.1
```

## 커밋 메시지 규칙

태그 생성 시 참고할 커밋 메시지 규칙:

### 기능 추가

```
feat: 새로운 기능 추가
feat: SMS 전송 기능 구현
```

### 버그 수정

```
fix: 버그 수정
fix: 인증 토큰 갱신 오류 수정
```

### 문서 업데이트

```
docs: README 업데이트
docs: API 문서 추가
```

### 성능 개선

```
perf: 성능 개선
perf: 메모리 사용량 최적화
```

### 리팩토링

```
refactor: 코드 리팩토링
refactor: 클래스 구조 개선
```

## 배포 확인

### GitHub Actions

1. GitHub 저장소 → **Actions** 탭
2. **Publish NuGet Package** 워크플로우 확인
3. 빌드 및 배포 상태 확인

### NuGet.org

1. [NuGet.org](https://www.nuget.org/packages/Infobank.Omni.Sdk.Cs) 방문
2. 패키지 페이지에서 최신 버전 확인
3. 다운로드 수 및 버전 히스토리 확인
