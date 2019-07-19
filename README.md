# Awesome Portal

Sinh viên thực hiện

| Sinh viên       | MSSV    |
| --------------- | ------- |
| Nguyễn Trần Hậu | 1612180 |
| Nguyễn Bữu Lộc  | 1612343 |
| Nguyễn Chí Thức | 1612677 |

## Mục lục

- Đặc tả
- Use case diagram
- Kiến trúc
- Database diagram
- Class diagram
- UI
- API
- Mã nguồn
- Demo

## Đặc tả

### Gửi dữ liệu từ app Create Data

Admin chọn dữ liệu từ file có đuôi là .txt, để có thể gửi danh sách sinh viên hoặc danh sách môn học lên server bằng cách chọn nút tìm kiếm file mà mình muốn gửi. Kèm theo đó phải chọn kiểu mà mình muốn gửi lên student hoặc là subject.

Nếu gửi thành công thì sẽ có thông báo là **`Dữ liệu đã được thêm vào Server`**, nếu đã tồn tại dữ liệu trên server thì sẽ được thông báo là **`Dữ liệu đã tồn tại`**.

Nếu định dạng file đã gửi sai cấu trúc theo mẫu thì sẽ có thông báo **`Sai kiểu dữ liệu ở File!, vui lòng tùy chỉnh file theo đúng định dạng`**.

Danh sách sinh viên được định dạng theo mẫu sau:

Tên sinh viên;MSSV;Mật khẩu;Viết tắc tên khoa; viết tắt tên chương trình; khóa

Ví dụ file students.txt chứa dữ liệu như sau:

```
Nguyễn Chí Thức;1612677;123456;CNTT;CNTN;2016
Nguyễn Trần Hậu;1612180;123456;CNTT;CNTN;2016
```

Danh sách Môn học được định dạng theo mẫu sau:

```
Tên học phần;số tín chỉ;số lượng sinh viên tối đa;năm mở; học kì mở;lớp;loại môn học;Mã học phần;trạng thái học phần(mở hay đóng);tuần dạy;tiết bắt đầu;tiết kết thúc; viết tắt chương trình cho môn học;có thể đăng kí chéo nhau giữa các lớp(kiểu int)
```

Ví dụ file subjects.txt chứa dữ liệu như sau:

```
Thiết kế phần mềm;4;50;2019;2;CNTT;16CNTN;bb;tkpm;true;2;3;6;cntn;0
Lập trình hướng đối tượng;4;50;2019;2;CNTT;16CNTN;bb;hdt;true;2;1;4;cntn;0
```

Bọn em đã có file demo sẵn trong mã nguồn tên là `subjects.txt` và `students.txt`

### Đăng nhập

Sinh viên có thể đăng nhập vào hệ thống bằng mã số sinh viên và mật khẩu của mình. Có được các thông tin cơ bản về tài khoản.

Sau khi đăng nhập thành công, sinh viên có thể sử dụng các tính năng khác bao gồm: _Đăng ký học phần_, _Xem thời khoá biểu của học kì bất kì_, _Xem điểm từng môn và tổng kết của học kì bất kì_.

Nếu đăng nhập thất bại sẽ có thông báo lỗi yêu cầu đăng nhập lại.

### Đăng ký học phần

Khi có các môn có thể đăng ký được, sinh viên vào mục đăng ký học phần sẽ thấy có 4 phần chính:

#### Thông tin chung

Các thông tin về **khoa, năm học, số tín chỉ tối đa** và **số môn đã đăng ký**.

#### Danh sách học phần đã đăng ký

Danh sách các học phần đã được sinh viên đăng ký. Danh sách này có thể được thay đổi trong thời gian đăng ký học phần: **đăng ký** thêm học phần mới, **xoá một hoặc nhiều** học phần được chọn.

#### Danh sách học phần được mở

Danh sách các học phần có thể được chọn để đăng ký.
Danh sách này có thể có một số học phần không thể được chọn do: đã có học phần tương ứng đã được chọn, số sinh viên học đã đạt tối đa.
Khi chọn vượt quá số tín chỉ tối đa trong học kì, sẽ có thông báo lỗi.

#### Danh sách học phần không thể đăng ký

Danh sách chứa các học phần không thể đăng ký.

### Xem thời khoá biểu

Sinh viên chọn năm học và học kỳ muốn xem thời khoá biểu. Sau một thời gian ngắn ứng dụng sẽ hiển thị thời khoá biểu của các môn học mà sinh viên đó sẽ học trong học kỳ tương ứng.

### Xem điểm

Sinh viên có thể lựa chọn năm học và học kỳ cụ thể để xem danh sách điểm các môn trong năm học/học kỳ đó.
Mỗi một record về môn học sẽ có điểm giữa kỳ, điểm cuối kỳ và điểm tổng kết của môn học. Cuối danh sách sẽ có tính tổng số tín chỉ các học phần được xem và điểm trung bình tích luỹ của các học phần đó.
**Chú ý:** có thể xem tất cả môn đã học bằng tuỳ chọn "Tất cả".

## Use case

# App Create Data

![Create](https://i.imgur.com/bcNUDuZ.png)

## Kiến trúc

Thiết kế theo mô hình client - server.

![1](https://i.imgur.com/ND9AVFq.png)

Server backend viết bằng ngôn ngữ Golang - host trên Heroku.

Database sử dụng Postgres.

App Student Portal và app Create data viết bằng Winform.

## Database diagram

### Thông tin bảng

`account` - tài khoản

`student` - sinh viên

`program` - lưu chương trình học (chính quy, cử nhân tài năng, ...)

`faculty` - khoa (công nghệ thông tin, sinh học, ...)

`subject` - học phần

`type_sub` - loại học phần (bắt buộc, tự chọn)

`require_sub` - học phần tiên quyết

`enroll` - học phần đăng ký đã được chấp nhận

`try_enroll` - học phần đăng ký chờ duyệt

### Quan hệ giữa các bảng

`student` chứa khóa chính của `account`, `program`, `faculty`

```
student.a_id -- account.a_id
student.p_id -- program.p_id
student.f_id -- faculty.f_id
```

`subject` chứa khóa chính của `program`, `faculty`, `type_sub`

```
subject.p_id -- program.p_id
subject.f_id -- faculty.f_id
subject.ts_id -- type_sub.ts_id
```

`enroll` và `try_enroll` chứa khóa chính của `student`, `subject`

````
enroll.s_id -- student.s_id
enroll.su_id -- subject.su_id
try_enroll.s_id -- student.s_id
try_enroll.su_id -- subject.su_id```
````

`require_sub` chứa khóa chính của `subject`

```
requiresub.rs_subject_pre -- subject.su_id
requiresub.rs_subject_cure -- subject.su_id
```

![2](https://i.imgur.com/kw8WzVL.png)

## Class Diagram

### App Student Portal

Class model và các class xử lý đơn giản (Logger)

![client](https://i.imgur.com/PrTwcA7.png)

Các class giao diện và xử lý hiển thị nội dung

![client](https://i.imgur.com/tXGtKCo.png)

### Server

Có 3 tầng:

- Storage: interface thể hiện thao tác với dữ liệu, implement tùy theo loại DBMS (postgres, mysql, ...)
- Service: xử lý business logic (đăng ký học phần, đăng nhập, ...)
- Transport: trả về dữ liệu thông qua API

![3](https://i.imgur.com/tLCFOyx.png)

## Design Patterns

### App Create Data

#### Factory

dựa vào loại đã được chọn ở combobox, ta sẽ có một chuỗi chứa kiểu dữ liệu, dựa vào chuỗi này để tạo ra một `List<Objects>` có thể là student hoặc là subject, sau đó convert thành một json để gửi lên server.

### App Student Portal

#### Singleton

- Sinh Viên: Mỗi phiên làm việc chỉ làm việc với duy nhất một tài khoản sinh viên. Do đó dùng mẫu singleton để thống nhất dữ liệu trên ứng dụng
- LogHelper: Để in log ra file
- Config: Là config duy nhất để ứng dụng chạy đúng(sẽ nói rõ ở dưới)

#### Strategy

- Config: Do tên thuộc tính của **đối tượng json** và **đường dẫn api** ở server online (do Hậu làm) khác với server test local (Lộc làm) nên dùng mẫu strategy để thay đổi môi trường test linh hoạt.

![Minh hoạ](https://i.imgur.com/osyq6ST.jpg)

#### Factory

- Các class model (Sinh viên, Học phần, ...): Hàm `Parse(Object)` nhận 1 object json nhận từ server và trả về đối tượng tương ứng.

### Server

#### Dependency Injection

Thay vì class chứa dependency, pass interface dependency vào hàm như argument

Ví dụ

```
func FillStudent(student *Student,
	programStorage ProgramStorage, facultyStorage FacultyStorage)
```

## UI

### App Create Data

https://i.imgur.com/gi5FxyH.png
Màn hình bắt đầu app, ở đây chọn loại dữ liệu và đường dẫn đến file dữ liệu

![img](https://i.imgur.com/rDNg6qf.png)

Khi nhấn vào nút tìm kiếm đường dẫn

![img](https://i.imgur.com/nbqeLIq.png)

### App Student Portal

#### Giao diện đăng nhập

![LoginUI](https://i.imgur.com/BMFXrvw.png)

![LoginUIFailed](https://i.imgur.com/67ILXC5.png)

#### Giao diện trang chính

![HomeUI](https://i.imgur.com/MIleOOo.png)

#### Giao diện đăng ký học phần

![DKHPUI1](https://i.imgur.com/7lsuehB.png)

![DKHPUI2](https://i.imgur.com/0qVlEZA.png)

#### Giao diện thời khoá biểu

![TKBUI](https://i.imgur.com/c3HQAHt.png)

#### Giao diện kết quả học tập

![KQUI](https://i.imgur.com/bLT1W3V.png)

## API

```
lấy thông tin sinh viên bằng cách truyền vào mssv
GET     /students/:mssv

thêm danh sách sinh viên vào server
POST    /students

xóa sinh viên thông qua mssv
DELETE  /students/:mssv

đăng nhập bằng cách nhập tài khoản và mật khẩu
POST    /auth/login

thêm danh sách chương trình học
POST    /programs

thêm danh sách khoa
POST    /faculties

lấy thông tin môn học thông qua id
GET     /subjects/:id

thêm danh sách môn học
POST    /subjects

thêm loại môn học bắt buộc hay tự chọn...
POST    /type_subs

xem thông tin sinh viên kèm kết quả học phần
GET     /students/:mssv/try_enrolls/:status

đăng ký học phần
POST    /try_enrolls

hủy đăng ký học phần
POST    /try_enrolls/delete
```

## Mã nguồn

App Student Portal [Github](https://github.com/1612343/AwesomePortal)

App Create Data [Github](https://github.com/sv1612677/pttkpm-cntn16-data)

Server [Github](https://github.com/1612180/pttkpm-cntn16-portal-api)

## Demo

[Part 1](https://youtu.be/qtZNwSwIz4s)

[Part 2](https://youtu.be/DFXqar1dvhw)
