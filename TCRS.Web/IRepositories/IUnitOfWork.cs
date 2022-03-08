using System;
using System.Threading.Tasks;
using TCRS.Web.Models;

namespace TCRS.Web.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClassTypeRep ClassType { get; }
        IClassRegisterRep ClassRegister { get; }
        IClassRoomRep ClassRoom { get; }
        IClassTimeTypeRep ClassTimeType { get; }
        ILessonRep Lesson { get; }
        IWeeklyScheduleRep WeeklySchedule { get; }
        IAcademicYearRep AcademicYear { get; }
        ISemesterRep Semester { get; }
        Task<int> CommitAsync();
    }


    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IClassTypeRep _classTypeRep;
        private IClassRegisterRep _classRegisterRep;
        private IClassRoomRep _classRoomRep;
        private IClassTimeTypeRep _classTimeTypeRep;
        private ILessonRep _lessonRep;
        private IWeeklyScheduleRep _weeklyScheduleRep;
        private IAcademicYearRep _academicYearRep;
        private ISemesterRep _semesterRep;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IClassTypeRep ClassType => _classTypeRep ??= new ClassTypeRep(_context);
        public IClassRegisterRep ClassRegister => _classRegisterRep ??= new ClassRegisterRep(_context);
        public IClassRoomRep ClassRoom => _classRoomRep ??= new ClassRoomRep(_context);
        public IClassTimeTypeRep ClassTimeType => _classTimeTypeRep ??= new ClassTimeTypeRep(_context);
        public ILessonRep Lesson => _lessonRep ??= new LessonRep(_context);
        public IWeeklyScheduleRep WeeklySchedule => _weeklyScheduleRep ??= new WeeklyScheduleRep(_context);
        public IAcademicYearRep AcademicYear => _academicYearRep ??= new AcademicYearRep(_context);
        public ISemesterRep Semester => _semesterRep ??= new SemesterRep(_context);

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
