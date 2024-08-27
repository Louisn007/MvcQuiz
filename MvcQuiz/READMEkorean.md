```markdown
# MvcQuiz

위 저장소는 "MvcQuiz"라는 ASP.NET Core MVC 웹 애플리케이션을 내포하고 있습니다.
위의 프로젝트는 ASP.NET Core를 사용하여 MVC 앱을 만드는 공식 Microsoft 튜토리얼을 기반으로 작동하고 있습니다.

**업로드하기**: [MvcQuiz on Somee.com](http://tjcode.somee.com/)

## 목차

1. [시작하기](#시작하기)
2. [사전 준비](#사전-준비)
3. [설치](#설치)
4. [데이터베이스 설정](#데이터베이스-설정)
5. [로컬에서 애플리케이션 실행](#로컬에서-애플리케이션-실행)
6. [호스팅 제공자에 배포](#호스팅-제공자에-배포)
7. [Somee.com에 배포](#someecom에-배포)
8. [감사의 말](#감사의-말)

## 시작하기

개발 및 테스트 목적으로 사용자의 기기에서 프로젝트를 설정하고 실행하는 방법에 대한 지침을 따르시길 바랍니다.

## 사전 준비

시작하기 전에 기기에 다음이 설치되어 있는지 확인하세요:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (버전 6.0 이상)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (ASP.NET 및 웹 개발 워크로드 포함)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (로컬 데이터베이스용, 선택 사항)
- [Git](https://git-scm.com/) (버전 관리용, 선택 사항)

## 설치

1. **저장소 클론**:
   ```bash
   git clone https://github.com/yourusername/MvcQuiz.git
   cd MvcQuiz
   ```

2. **Visual Studio에서 프로젝트 열기**:
   - Visual Studio 2022를 실행합니다.
   - `MvcQuiz.sln` 솔루션 파일을 엽니다.

## 데이터베이스 설정

### 로컬 개발 (선택 사항)

로컬에서 데이터베이스와 함께 애플리케이션을 실행하려면 다음 단계를 따르기오:

1. **연결 문자열 업데이트**:
   - `appsettings.json` 파일열기.
   - `DefaultConnection` 문자열을 로컬 SQL Server 인스턴스로 수정하기기.
   - 예시:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MvcQuizDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

2. **마이그레이션 적용**:
   - Visual Studio의 패키지 관리자 콘솔을 엽니다 (`도구 > NuGet 패키지 관리자 > 패키지 관리자 콘솔`).
   - 다음 명령어를 실행하여 마이그레이션을 적용하고 데이터베이스를 만드시오오:
     ```bash
     Update-Database
     ```

## 로컬에서 애플리케이션 실행

1. **프로젝트 빌드**:
   - `Ctrl+Shift+B`를 누르거나 `빌드 > 솔루션 빌드`로 이동합니다.

2. **프로젝트 실행**:
   - `F5`를 누르거나 `디버그 > 디버깅 시작`으로 이동합니다.
   - 애플리케이션이 기본 웹 브라우저에서 `https://localhost:5001` (또는 유사한 로컬 URL)에서 실행됩니다.

## 호스팅 제공자에 배포

1. **프로젝트 배포**:
   - 솔루션 탐색기에서 프로젝트를 마우스 오른쪽 버튼으로 클릭하고 `게시`를 선택합니다.
   - 배포하려는 대상(예: 폴더, Azure 등)을 선택합니다.
   - 필요한 설정을 구성하고 배포합니다.

2. **FTP/FTPS로 배포 (선택 사항)**:
   - FTP를 통해 배포하는 경우 FTP 클라이언트를 사용하여 게시된 파일을 호스팅 제공자에 업로드합니다.

## Somee.com에 배포

### 1. SQL Server 데이터베이스 설정

- Somee.com 제어판에 로그인합니다.
- 새 SQL Server 데이터베이스를 만듭니다.
- 제공된 연결 세부 정보를 기록합니다 (서버 이름, 데이터베이스 이름, 사용자 이름, 비밀번호).

### 2. 연결 문자열 업데이트

- `appsettings.json` 파일을 엽니다.
- Somee.com에서 제공된 `DefaultConnection` 문자열로 교체합니다.
- 예시:
  ```json
  "ConnectionStrings": {
      "DefaultConnection": "Server=somee_sql_server_address;Database=your_database_name;User Id=your_username;Password=your_password;"
  }
  ```

### 3. `web.config` 파일 수정

- Somee.com의 요구 사항에 맞게 루트 디렉터리에 있는 `web.config` 파일을 업데이트합니다.
- 예시:
  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <configuration>
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified"/>
      </handlers>
      <aspNetCore processPath=".\MvcQuiz.dll" stdoutLogEnabled="false" hostingModel="InProcess"/>
    </system.webServer>
  </configuration>
  ```

### 4. Somee.com에 파일 업로드

- FTP 클라이언트(예: FileZilla)를 사용하여 게시된 파일을 Somee.com에 업로드합니다.
- Somee.com에서 제공된 자격 증명을 사용하여 FTP 서버에 연결합니다.
- 모든 파일을 루트 디렉터리 또는 지정된 디렉터리에 업로드합니다.

### 5. 배포 테스트

- Somee.com에서 웹사이트 URL을 방문합니다 (예: `http://tjcode.somee.com/`).
- 사이트가 제대로 실행되는지 확인합니다.

## 감사의 말

- 이 프로젝트는 [ASP.NET Core MVC 튜토리얼](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio)을 기반으로 합니다.
```

You can copy and paste this into your `README.md` file on GitHub.
