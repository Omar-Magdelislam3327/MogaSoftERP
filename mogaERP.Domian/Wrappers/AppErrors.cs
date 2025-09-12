using mogaERP.Domain.Enums;

namespace mogaERP.Domain.Wrappers;
public class AppErrors
{
    // General Success
    public static readonly ErrorModel Success = new("تمت العملية بنجاح", AppStatusCode.Success);
    public static readonly ErrorModel AddSuccess = new("تمت الإضافة بنجاح", AppStatusCode.Success);
    public static readonly ErrorModel UpdateSuccess = new("تم التعديل بنجاح", AppStatusCode.Success);
    public static readonly ErrorModel DeleteSuccess = new("تم الحذف بنجاح", AppStatusCode.Success);
    public static readonly ErrorModel StatusChangedSuccess = new("تم تغيير الحالة بنجاح", AppStatusCode.Success);
    public static readonly ErrorModel SuccessLogin = new("تم تسجيل الدخول بنجاح", AppStatusCode.Success);
    public static readonly ErrorModel SuccessRegister = new("تم تسجيل مستخدم جديد بنجاح", AppStatusCode.Success);

    // General Failures
    public static readonly ErrorModel TransactionFailed = new("لقد حدث خطأ", AppStatusCode.Failed);
    public static readonly ErrorModel NotFound = new("هذا العنصر غير موجود", AppStatusCode.NotFound);
    public static readonly ErrorModel AlreadyExists = new("هذا العنصر موجود بالفعل", AppStatusCode.Conflict);

    // Validation Errors
    public static readonly ErrorModel InvalidStatus = new("هذه الحالة غير صالحة", AppStatusCode.Failed);
    public static readonly ErrorModel InvalidType = new("هذا النوع غير صالح", AppStatusCode.Failed);
    public static readonly ErrorModel InvalidGender = new("هذا الجنس غير صالح", AppStatusCode.Failed);
    public static readonly ErrorModel InvalidMaritalStatus = new("هذه الحالة الاجتماعية غير صالحة", AppStatusCode.Failed);
    public static readonly ErrorModel NotEmergency = new("هذا الإجراء مسموح به فقط لنوع الطوارئ", AppStatusCode.Failed);

    // Schedule / Appointment Errors
    public static readonly ErrorModel ScheduleFull = new("تم الوصول للحد الأقصى للحجز اليوم", AppStatusCode.Failed);
    public static readonly ErrorModel ScheduleNotFound = new("لا يوجد ميعاد متاح في هذا الوقت", AppStatusCode.NotFound);

    // Auth / User Errors
    public static readonly ErrorModel InvalidCredentials = new("اسم المستخدم أو كلمة المرور غير صالح", AppStatusCode.Unauthorized);
    public static readonly ErrorModel DuplicateEmail = new("البريد الإلكتروني مسجل مسبقاً", AppStatusCode.Conflict);
    public static readonly ErrorModel EmailAlreadyExists = new("تم استخدام البريد الإلكتروني بالفعل بواسطة مستخدم آخر", AppStatusCode.Conflict);
    public static readonly ErrorModel UserNotFound = new("هذا المستخدم غير موجود", AppStatusCode.NotFound);

    // User Update Failures
    public static readonly ErrorModel FailedToUpdateEmail = new("فشل في تعديل البريد الإلكتروني", AppStatusCode.Failed);
    public static readonly ErrorModel FailedToUpdatePassword = new("فشل في تعديل كلمة المرور", AppStatusCode.Failed);
    public static readonly ErrorModel FailedToAssignNewRole = new("فشل في تعيين صلاحية جديدة", AppStatusCode.Failed);

    // Accounts
    public static readonly ErrorModel ParentAccountNotFound = new("الحساب الأب غير موجود", AppStatusCode.NotFound);

    // Staff
    public static readonly ErrorModel CalcStaffSalaries = new("لقد تم حساب مرتبات الموظفين لهذا الشهر بالفعل", AppStatusCode.Failed);
}
